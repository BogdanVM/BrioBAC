package com.example.mihai.briobac;

import android.content.Context;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import java.util.Calendar;

public class IQTestStart extends AppCompatActivity {

    Button startBtn;
    Context context = this;

    public int current_question = 1;
    public String[] time_per_question = new String[31];
    public int[] answered_correctly = new int[31];
    public int[] chosen_answer = new int[31];

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_iqtest_start);

        startBtn = (Button) findViewById(R.id.activity_iqtest_start_testStart_btn);
        startBtn.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {

                startActivity(new Intent(context, IQTest.class));
            }
        });
    }
}
