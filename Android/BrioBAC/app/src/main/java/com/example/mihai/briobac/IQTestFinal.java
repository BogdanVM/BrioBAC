package com.example.mihai.briobac;

import android.content.Context;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.view.ViewGroup;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import com.example.mihai.briobac.DatabaseClasses.TestIQTableClass;

public class IQTestFinal extends AppCompatActivity {

    IQTestStart iqTestStart = new IQTestStart();
    IQTest iqTest = new IQTest();
    TestIQTableClass testIQTableClass = new TestIQTableClass(this);

    Context context = this;

    TableLayout tableLayout;

    int no_questions_answered;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_iqtest_final);

        tableLayout = (TableLayout) findViewById(R.id.activity_iqtest_final_tableLayout);

        no_questions_answered = iqTestStart.answered_correctly.length;

        for(int index = 0; index < no_questions_answered; index++){

            TableRow newTableRow = new TableRow(context);

            TableRow.LayoutParams layoutParams = new TableRow.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT,
                    ViewGroup.LayoutParams.WRAP_CONTENT);
            layoutParams.setMargins(0, 0, 0, 15);

            newTableRow.setLayoutParams(new TableRow.LayoutParams(layoutParams));
            newTableRow.setGravity(Gravity.CENTER_HORIZONTAL);

            int chosen_answer = iqTestStart.chosen_answer[index];
            String time_spent = iqTestStart.time_per_question[index];

            TextView no_question = createTableElement(String.valueOf(index), false);
            TextView answer_txtView = createTableElement(String.valueOf(chosen_answer), true);
            TextView time_txtView = createTableElement(time_spent, true);

            newTableRow.addView(no_question);
            newTableRow.addView(answer_txtView);
            newTableRow.addView(time_txtView);

            if (chosen_answer == iqTest.right_answers[index])
                newTableRow.setBackgroundColor(Color.parseColor("#2c9400"));
            else
                newTableRow.setBackgroundColor(Color.parseColor("#ba0000"));

            tableLayout.addView(newTableRow);
        }

        //testIQTableClass.insertInto()
    }

    private TextView createTableElement(String labelTxt, boolean padding){
        TextView newTextView = new TextView(context);

        newTextView.setText(labelTxt);
        newTextView.setTextSize(30);
        newTextView.setGravity(Gravity.CENTER_HORIZONTAL);
        newTextView.setTextColor(Color.parseColor("#ffffff"));

        if (padding)
            newTextView.setPadding(30, 0, 0, 0);

        return newTextView;
    }
}
