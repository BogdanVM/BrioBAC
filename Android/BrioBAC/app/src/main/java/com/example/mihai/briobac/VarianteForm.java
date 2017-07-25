package com.example.mihai.briobac;

import android.content.Context;
import android.content.Intent;
import android.content.res.AssetManager;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

public class VarianteForm extends AppCompatActivity {

    Context context = this;

    Button variante_btn;
    Button solutii_btn;
    Button programa_btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_variante_form);

        variante_btn = (Button) findViewById(R.id.activity_variante_form_variante_btn);
        solutii_btn = (Button) findViewById(R.id.activity_variante_form_solutii_btn);
        programa_btn = (Button) findViewById(R.id.activity_variante_form_programa_btn);

        variante_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                CopyReadAssets("variante.pdf");
            }
        });

        solutii_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                CopyReadAssets("solutii_variante.pdf");
            }
        });

        programa_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                CopyReadAssets("programa.pdf");
            }
        });
    }

    private void CopyReadAssets(String pdf_File) {
        AssetManager assetManager = context.getAssets();

        InputStream in = null;
        OutputStream out = null;
        File file = new File(context.getFilesDir(), pdf_File);
        try {
            in = assetManager.open(pdf_File);
            out = context.openFileOutput(file.getName(), Context.MODE_WORLD_READABLE);

            copyFile(in, out);
            in.close();
            in = null;
            out.flush();
            out.close();
            out = null;
        } catch (Exception e) {
            Log.e("tag", e.getMessage());
        }

        Intent intent = new Intent(Intent.ACTION_VIEW);
        intent.setDataAndType(
                Uri.parse("file://" + context.getFilesDir() + "/" + pdf_File),
                "application/pdf");

        startActivity(intent);
    }

    private void copyFile(InputStream in, OutputStream out) throws IOException {
        byte[] buffer = new byte[1024];
        int read;
        while ((read = in.read(buffer)) != -1) {
            out.write(buffer, 0, read);
        }
    }
}
