package com.example.mihai.briobac;


import android.app.ProgressDialog;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Build;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.mihai.briobac.DatabaseClasses.ConturiTableClass;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.UnsupportedEncodingException;
import java.net.MalformedURLException;
import java.net.URL;
import java.security.NoSuchAlgorithmException;
import java.util.Calendar;

import javax.net.ssl.HttpsURLConnection;

public class LoginForm extends AppCompatActivity {

    ConturiTableClass conturiTableClass = new ConturiTableClass(this);

    TextView textView;

    private Button registerButton;
    private Button loginButton;

    private EditText emailEditTxt;
    private EditText pwdEditTxt;

    private String email;
    private String password;

    String hashed_password;
    Context context;

    public static String ID = "";
    public static String NAME = "";
    public static String EMAIL = "";
    public static String PASSWORD = "";
    public static String UPDATED = "";
    public static String LAST_UPDATE = "";
    public static String PROFILE_PIC = "";

    PasswordHash passwordHash = new PasswordHash();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_form);

        registerButton = (Button) findViewById(R.id.activity_login_form_InregistrareBtn);
        loginButton = (Button) findViewById(R.id.activity_login_form_LoginBtn);

        //textView = (TextView) findViewById(R.id.sqlite_content);

        context = this;

        emailEditTxt = (EditText) findViewById(R.id.activity_login_form_emailEditText);
        pwdEditTxt = (EditText) findViewById(R.id.activity_login_form_pwdEditText);

        email = emailEditTxt.getText().toString();
        password = pwdEditTxt.getText().toString();

        final Intent regFormIntent = new Intent(this, RegisterForm.class);


        SQLiteDatabase db = conturiTableClass.getWritableDatabase();

        String count = "SELECT count(*) FROM conturi";
        Cursor mcursor = db.rawQuery(count, null);

        mcursor.moveToFirst();
        int rows = mcursor.getInt(0);
        if(rows>0)
        {
            startActivity(new Intent(context, MainMenu.class));
            finish();
        }

       /* SQLiteDatabase sqLiteDatabase = conturiTableClass.getReadableDatabase();
        Cursor cursor = sqLiteDatabase.rawQuery("SELECT * FROM Conturi", null);

        cursor.moveToFirst();
        do{

            String NAME_1  = cursor.getString(1);
            textView.setText(NAME_1);

        }while (cursor.moveToNext());*/

        registerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startActivity(new Intent(regFormIntent));
            }
        });

        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                email = emailEditTxt.getText().toString();
                password = pwdEditTxt.getText().toString();



                try {
                    hashed_password = passwordHash.SHA1(password);
                } catch (NoSuchAlgorithmException e) {
                    e.printStackTrace();
                } catch (UnsupportedEncodingException e) {
                    e.printStackTrace();
                }

                BackGround backGround = new BackGround();
                backGround.execute(email, hashed_password);
            }
        });
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

    class BackGround extends AsyncTask<String, String, String> {


        ProgressDialog loading;
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            loading = ProgressDialog.show(LoginForm.this, "Se extrag datele", "Va rugam sa asteptati...", true, true);
        }

        @Override
        protected String doInBackground(String... params) {
            String email = params[0];
            String password = params[1];
            String data="";
            int tmp;

            try {
                URL url = new URL("https://typenthink.000webhostapp.com/php_scripts_briobac/login_activity.php");
                String urlParams = "Password="+password+"&Email="+email;

                HttpsURLConnection httpURLConnection = (HttpsURLConnection) url.openConnection();
                httpURLConnection.setDoOutput(true);
                OutputStream os = httpURLConnection.getOutputStream();
                os.write(urlParams.getBytes());
                os.flush();
                os.close();

                InputStream is = httpURLConnection.getInputStream();
                while((tmp=is.read())!=-1){
                    data+= (char)tmp;
                }

                is.close();
                httpURLConnection.disconnect();

                return data;

            } catch (MalformedURLException e) {

                e.printStackTrace();
                return "Exception: "+e.getMessage();

            } catch (IOException e) {

                e.printStackTrace();
                return "Exception: "+e.getMessage();

            }
        }

        @Override
        protected void onPostExecute(String s) {
            String err=null;
            loading.dismiss();

            if (s.equals("User not found"))
            {
                pwdEditTxt.setText("");
                emailEditTxt.setText("");

                createAlert("Utilizator inexistent", "Utilizatorul nu a fost gasit in baza de date");

            }
            else {

                String rootString="";
                try {
                    JSONObject user_data = new JSONObject(s);
                    NAME = user_data.getString("Nume");
                    PASSWORD = user_data.getString("Parola");
                    EMAIL = user_data.getString("Email");
                    PROFILE_PIC = user_data.getString("Poza");
                    UPDATED = user_data.getString("Actualizat");
                    LAST_UPDATE = user_data.getString("Ultima_Actualizare");

                } catch (JSONException e) {
                    e.printStackTrace();
                    err = "Exception: " + e.getMessage();
                }

                Intent i = new Intent(context, MainMenu.class);
                byte[] profile_image = PROFILE_PIC.getBytes();
                //Toast.makeText(context, rootString, Toast.LENGTH_LONG).show();
                int updated = Integer.parseInt(UPDATED);

                conturiTableClass.insertInto(NAME, EMAIL, PASSWORD, updated, LAST_UPDATE, null);

                startActivity(i);
                finish();
            }

        }
    }

}
