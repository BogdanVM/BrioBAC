package com.example.mihai.briobac.DatabaseClasses;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

/**
 * Created by Mihai on 21.07.2017.
 */

public class IntrebariTableClass extends SQLiteOpenHelper {

    private static final String DATABASE_NAME = "Briobac.db";
    private static final String TABLE_NAME = "Intrebari";
    private static final String COLUMN_1 = "ID";
    private static final String COLUMN_2 = "Raspuns_corect";

    public IntrebariTableClass(Context context) {
        super(context, DATABASE_NAME, null, 1);
    }


    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL("CREATE TABLE " + TABLE_NAME + " (" +
                COLUMN_1 + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                COLUMN_2 + " INTEGER" +
                ")");

    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        sqLiteDatabase.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME);
        onCreate(sqLiteDatabase);
    }

    @Override
    public void onDowngrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        super.onDowngrade(db, oldVersion, newVersion);
    }

    public boolean insertInto(int right_answer){
        SQLiteDatabase database = this.getWritableDatabase();

        ContentValues contentValues = new ContentValues();

        contentValues.put(COLUMN_2, right_answer);

        long isInserted = database.insert(TABLE_NAME, null, contentValues);

        if (isInserted == -1)
            return false;

        return true;
    }

    public Cursor getData(){
        SQLiteDatabase database = this.getWritableDatabase();

        Cursor data = database.rawQuery("SELECT * FROM " + TABLE_NAME, null);

        return data;
    }
}
