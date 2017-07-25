package com.example.mihai.briobac;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Build;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Patterns;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.mihai.briobac.DatabaseClasses.ConturiTableClass;
import com.example.mihai.briobac.MenuTabs.LearnTab;
import com.example.mihai.briobac.MenuTabs.TestsTab;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.UnsupportedEncodingException;
import java.net.MalformedURLException;
import java.net.URL;
import java.security.NoSuchAlgorithmException;
import java.util.Calendar;
import java.util.Date;

import javax.net.ssl.HttpsURLConnection;

public class RegisterForm extends AppCompatActivity {

    Button exitButton;
    Button registerButton;

    EditText nameEditText;
    EditText emailEditText;
    EditText passwordEditText;
    EditText confPasswordEditText;
    EditText prenumeEditText;

    String name;
    String prenume;
    String email;
    String password;
    String confPassword;

    String hashed_password;

    byte[] initialProfileImage;
    ConturiTableClass conturiTableClass = new ConturiTableClass(this);
    Context context;

    PasswordHash passwordHash = new PasswordHash();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register_form);

        context = this;

        exitButton = (Button) findViewById(R.id.activity_register_form_exitBtn);
        registerButton = (Button) findViewById(R.id.activity_register_form_regBtn);

        nameEditText = (EditText) findViewById(R.id.activity_register_form_numeEditText);
        emailEditText = (EditText) findViewById(R.id.activity_register_form_emailEditText);
        passwordEditText = (EditText) findViewById(R.id.activity_register_form_pwdEditText);
        confPasswordEditText = (EditText) findViewById(R.id.activity_register_form_pwdConfEditText);
        prenumeEditText = (EditText) findViewById(R.id.activity_register_form_prenumeEditText);


        exitButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        registerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {


                Bitmap profile_pic_initial = BitmapFactory.decodeResource(getResources(), R.drawable.initial_avatar);

                ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();

                profile_pic_initial.compress(Bitmap.CompressFormat.PNG, 100, byteArrayOutputStream);
                initialProfileImage = byteArrayOutputStream.toByteArray();

                //initialProfileImage = getBytesFromBitmap(BitmapFactory.decodeResource(getResources(), R.drawable.initial_avatar));
                name = nameEditText.getText().toString().trim();
                prenume = prenumeEditText.getText().toString().trim();
                email = emailEditText.getText().toString().trim();
                password = passwordEditText.getText().toString().trim();
                confPassword = confPasswordEditText.getText().toString().trim();

                try {

                    hashed_password = passwordHash.SHA1(password);
                } catch (NoSuchAlgorithmException e) {
                    e.printStackTrace();
                } catch (UnsupportedEncodingException e) {
                    e.printStackTrace();
                }

                if (everythingFine()) {
                    //Verificam daca dispozitivul este conectat la internet
                    if (connectedToInternet()) {


                        //Inseram datele introduse atat in baza de date sqlite, cat si in baza de date de pe serverul online

                        BackGround backGround = new BackGround();
                        backGround.execute(name + " " + prenume, email, hashed_password, "1", Calendar.getInstance().getTime().toString(),
                                initialProfileImage.toString());
                    } else {
                        //Inseram datele introduse doar in baza de date sqlite

                        boolean inserted = conturiTableClass.insertInto(name, email, hashed_password, 0, null, null);
                        if (inserted) {
                            //inchidem activitatea curenta
                            createAlert("Date inserate", "Datele au fost inserate cu succes");
                            startActivity(new Intent(context, MainMenu.class));
                            finish();
                        } else {
                            //afisam un mesaj de eroare
                            createAlert("Date inserate", "A aparut o eroare la server");
                        }
                    }
                }
            }


        });
    }

    
    private boolean allFieldsInfo(EditText[] textInputs){
        for (EditText input : textInputs) {
            if (input.getText().toString().equals(""))
                return false;
        }

        return true;
    }

    private boolean validEmail(String email){
        return Patterns.EMAIL_ADDRESS.matcher(email).matches();
    }

    private boolean everythingFine(){
        if (allFieldsInfo(new EditText[] { nameEditText, prenumeEditText, emailEditText, passwordEditText, confPasswordEditText })){
            if(validEmail(email)){
                if(password.length() >= 5) {
                    if (password.equals(confPassword)) {
                       return true;
                    }
                }
            }
        }
        return false;
    }

    private boolean connectedToInternet(){

        ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);

        NetworkInfo networkInfo = connectivityManager.getActiveNetworkInfo();

        return networkInfo != null && networkInfo.isConnected();
    }

    private void createAlert(String title, String message){
        final AlertDialog.Builder alertBuilder;

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP){
            alertBuilder = new AlertDialog.Builder(context, android.R.style.Theme_Material_Light_Dialog_Alert);
        }

        else{
            alertBuilder = new AlertDialog.Builder(context);
        }

        alertBuilder.setTitle(title)
                .setIcon(android.R.drawable.ic_dialog_alert)
                .setMessage(message)
                .setPositiveButton("Bine", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.cancel();
                    }
                })

                .setNegativeButton("Anuleaza", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.cancel();
                    }
                })
                .show();
    }

    public byte[] getBytesFromBitmap(Bitmap bitmap) {

        ByteArrayOutputStream stream = new ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.JPEG, 70, stream);

        return stream.toByteArray();
    }

     class BackGround extends AsyncTask<String, String, String>{

        ProgressDialog loading;

        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            loading = ProgressDialog.show(context, "Se retin datele", "Va rugam sa asteptai...", true, true);
        }

        @Override
        protected String doInBackground(String... params) {

            String name = params[0];
            String email = params[1];
            String password = params[2];
            String updated = params[3];
            String last_update = params[4];
            String profilePic = params[5];

            String data = "";
            int tmp;

            try{
                URL url = new URL("https://typenthink.000webhostapp.com/php_scripts_briobac/register_activity.php");
                String urlParams = "Nume=" + name + "&Email=" + email + "&Parola=" + password + "&Actualizat=" + updated +
                                   "&Ultima_Actualizare=" + last_update + "&Poza=" + profilePic;

                HttpsURLConnection httpsURLConnection = (HttpsURLConnection) url.openConnection();
                httpsURLConnection.setDoOutput(true);

                OutputStream outputStream = httpsURLConnection.getOutputStream();
                outputStream.write(urlParams.getBytes());
                outputStream.flush();
                outputStream.close();

                InputStream inputStream = httpsURLConnection.getInputStream();
                while ((tmp = inputStream.read()) != -1){
                    data += (char)tmp;
                }

                inputStream.close();
                httpsURLConnection.disconnect();

                return data;
            }

            catch (MalformedURLException e) {
                e.printStackTrace();
                return "Exception: "+e.getMessage();
            }

            catch (IOException e) {
                e.printStackTrace();
                return "Exception: "+e.getMessage();
            }
        }

        @Override
        protected void onPostExecute(String s) {

            loading.dismiss();

            if (s.equals("")){
                Intent intent = new Intent(context, MainMenu.class);

                Calendar currentDateTime = Calendar.getInstance();
                conturiTableClass.insertInto(name, email, hashed_password, 1, currentDateTime.getTime().toString() , initialProfileImage);

                startActivity(intent);
                finish();
            }

            else
                createAlert("Utilizator existent", "Utilizatorul introdus exista deja in baza de date");
        }
    }
}

