package com.example.mihai.briobac;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.CountDownTimer;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.mihai.briobac.DatabaseClasses.IntrebariTableClass;
import com.example.mihai.briobac.DatabaseClasses.TestIQTableClass;

public class IQTest extends AppCompatActivity {

    Context context = this;
    IntrebariTableClass intrebariTableClass = new IntrebariTableClass(context);
    IQTestStart iqTestStart = new IQTestStart();

    public int[] right_answers = {};
    int current_question;

    double total_time = 60.00;
    double time_left = 60.00;

    ImageButton answer_1_ImageButton;
    ImageButton answer_2_ImageButton;
    ImageButton answer_3_ImageButton;
    ImageButton answer_4_ImageButton;
    ImageButton answer_5_ImageButton;
    ImageButton answer_6_ImageButton;

    TextView time_TextView;
    ImageView question_ImageView;

    Bitmap question;
    Bitmap answer_1, answer_2, answer_3, answer_4, answer_5, answer_6;

    CountDownTimer countDownTimer;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_iqtest);

        current_question = iqTestStart.current_question;

        question_ImageView = (ImageView) findViewById(R.id.activity_iqtest_intrebare_img);

        answer_1_ImageButton = (ImageButton) findViewById(R.id.activity_iqtest_raspuns1_img);
        answer_2_ImageButton = (ImageButton) findViewById(R.id.activity_iqtest_raspuns2_img);
        answer_3_ImageButton = (ImageButton) findViewById(R.id.activity_iqtest_raspuns3_img);
        answer_4_ImageButton = (ImageButton) findViewById(R.id.activity_iqtest_raspuns4_img);
        answer_5_ImageButton = (ImageButton) findViewById(R.id.activity_iqtest_raspuns5_img);
        answer_6_ImageButton = (ImageButton) findViewById(R.id.activity_iqtest_raspuns6_img);

        time_TextView = (TextView) findViewById(R.id.activity_iqtest_time_label);

        int question_resourceID = context.getResources().getIdentifier("intrebare_" + current_question + ".png",
                "drawable", context.getPackageName());

        int answer_1_resourceID = context.getResources().getIdentifier("raspuns_" + current_question + "_1.png",
                "drawable", context.getPackageName());
        int answer_2_resourceID = context.getResources().getIdentifier("raspuns_" + current_question + "_2.png",
                "drawable", context.getPackageName());
        int answer_3_resourceID = context.getResources().getIdentifier("raspuns_" + current_question + "_3.png",
                "drawable", context.getPackageName());
        int answer_4_resourceID = context.getResources().getIdentifier("raspuns_" + current_question + "_4.png",
                "drawable", context.getPackageName());
        int answer_5_resourceID = context.getResources().getIdentifier("raspuns_" + current_question + "_5.png",
                "drawable", context.getPackageName());
        int answer_6_resourceID = context.getResources().getIdentifier("raspuns_" + current_question + "_6.png",
                "drawable", context.getPackageName());

        question = BitmapFactory.decodeResource(context.getResources(), question_resourceID);

        answer_1 = BitmapFactory.decodeResource(context.getResources(), answer_1_resourceID);
        answer_2 = BitmapFactory.decodeResource(context.getResources(), answer_2_resourceID);
        answer_3 = BitmapFactory.decodeResource(context.getResources(), answer_3_resourceID);
        answer_4 = BitmapFactory.decodeResource(context.getResources(), answer_4_resourceID);
        answer_5 = BitmapFactory.decodeResource(context.getResources(), answer_5_resourceID);
        answer_6 = BitmapFactory.decodeResource(context.getResources(), answer_6_resourceID);

        question_ImageView.setImageBitmap(question);

        answer_1_ImageButton.setImageBitmap(answer_1);
        answer_2_ImageButton.setImageBitmap(answer_2);
        answer_3_ImageButton.setImageBitmap(answer_3);
        answer_4_ImageButton.setImageBitmap(answer_4);
        answer_5_ImageButton.setImageBitmap(answer_5);
        answer_6_ImageButton.setImageBitmap(answer_6);


        answer_1_ImageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if (right_answers[current_question - 1] == 1) {
                    iqTestStart.answered_correctly[current_question - 1] = 1;
                } else {
                    iqTestStart.answered_correctly[current_question - 1] = 0;
                }

                iqTestStart.time_per_question[current_question - 1] = String.valueOf(total_time - time_left);
                iqTestStart.chosen_answer[current_question - 1] = 1;
                iqTestStart.current_question++;

                if (iqTestStart.current_question == 31) {

                    startActivity(new Intent(context, IQTestFinal.class));
                    finish();
                } else {
                    startActivity(new Intent(context, IQTest.class));
                    finish();
                }
            }
        });

        answer_2_ImageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if (right_answers[current_question - 1] == 2) {
                    iqTestStart.answered_correctly[current_question - 1] = 1;
                } else {
                    iqTestStart.answered_correctly[current_question - 1] = 0;
                }

                iqTestStart.time_per_question[current_question - 1] = String.valueOf(total_time - time_left);
                iqTestStart.chosen_answer[current_question - 1] = 2;
                iqTestStart.current_question++;

                if (iqTestStart.current_question == 31) {

                    startActivity(new Intent(context, IQTestFinal.class));
                    finish();
                } else {
                    startActivity(new Intent(context, IQTest.class));
                    finish();
                }
            }
        });

        answer_3_ImageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if (right_answers[current_question - 1] == 3) {
                    iqTestStart.answered_correctly[current_question - 1] = 1;
                } else {
                    iqTestStart.answered_correctly[current_question - 1] = 0;
                }

                iqTestStart.time_per_question[current_question - 1] = String.valueOf(total_time - time_left);
                iqTestStart.chosen_answer[current_question - 1] = 3;
                iqTestStart.current_question++;

                if (iqTestStart.current_question == 31) {

                    startActivity(new Intent(context, IQTestFinal.class));
                    finish();
                } else {
                    startActivity(new Intent(context, IQTest.class));
                    finish();
                }
            }
        });

        answer_4_ImageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if (right_answers[current_question - 1] == 4) {
                    iqTestStart.answered_correctly[current_question - 1] = 1;
                } else {
                    iqTestStart.answered_correctly[current_question - 1] = 0;
                }

                iqTestStart.time_per_question[current_question - 1] = String.valueOf(total_time - time_left);
                iqTestStart.chosen_answer[current_question - 1] = 4;
                iqTestStart.current_question++;

                if (iqTestStart.current_question == 31) {

                    startActivity(new Intent(context, IQTestFinal.class));
                    finish();
                } else {
                    startActivity(new Intent(context, IQTest.class));
                    finish();
                }
            }
        });

        answer_5_ImageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if (right_answers[current_question - 1] == 5) {
                    iqTestStart.answered_correctly[current_question - 1] = 1;
                } else {
                    iqTestStart.answered_correctly[current_question - 1] = 0;
                }

                iqTestStart.time_per_question[current_question - 1] = String.valueOf(total_time - time_left);
                iqTestStart.chosen_answer[current_question - 1] = 5;
                iqTestStart.current_question++;

                if (iqTestStart.current_question == 31) {

                    startActivity(new Intent(context, IQTestFinal.class));
                    finish();
                } else {
                    startActivity(new Intent(context, IQTest.class));
                    finish();
                }
            }
        });

        answer_6_ImageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if (right_answers[current_question - 1] == 6) {
                    iqTestStart.answered_correctly[current_question - 1] = 1;
                } else {
                    iqTestStart.answered_correctly[current_question - 1] = 0;
                }

                iqTestStart.time_per_question[current_question - 1] = String.valueOf(total_time - time_left);
                iqTestStart.chosen_answer[current_question - 1] = 6;
                iqTestStart.current_question++;

                if (iqTestStart.current_question == 31) {

                    startActivity(new Intent(context, IQTestFinal.class));
                    finish();
                } else {
                    startActivity(new Intent(context, IQTest.class));
                    finish();
                }
            }
        });

        countDownTimer = new CountDownTimer(60000, 100) {
            @Override
            public void onTick(long l) {
                time_left -= 0.01;
                time_TextView.setText(String.valueOf(time_left));
            }

            @Override
            public void onFinish() {
                iqTestStart.current_question++;
                iqTestStart.time_per_question[current_question - 1] = "60.00";

                startActivity(new Intent(context, IQTestFinal.class));
                finish();
            }
        }.start();
    }

//    private boolean checkIfTableIsEmpty(){
//
//        SQLiteDatabase sqLiteDatabase = intrebariTableClass.getWritableDatabase();
//
//        String countQuery = "SELECT Count(*) FROM TestIQ";
//
//        Cursor cursor = sqLiteDatabase.rawQuery(countQuery, null);
//        cursor.moveToFirst();
//        int element_no = cursor.getInt(0);
//
//        if (element_no > 0) return false;
//        return true;
//    }
}
