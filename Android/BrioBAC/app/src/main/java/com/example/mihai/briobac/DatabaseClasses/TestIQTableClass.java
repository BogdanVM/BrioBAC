package com.example.mihai.briobac.DatabaseClasses;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.util.Date;

/**
 * Created by Mihai on 28.06.2017.
 */

public class TestIQTableClass extends SQLiteOpenHelper{

    private static final String DATABASE_NAME = "Briobac.db";
    private static final String TABLE_NAME = "TestIQ";
    private static final String COLUMN_1 = "ID";
    private static final String COLUMN_2 = "ID_user";
    private static final String COLUMN_3 = "Scor";
    private static final String COLUMN_4 = "Timp";
    private static final String COLUMN_5 = "Actualizat";
    private static final String COLUMN_6 = "Ultima_Actualizare";

    public TestIQTableClass(Context context) {
        super(context, DATABASE_NAME, null, 1);
    }


    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL("CREATE TABLE " + TABLE_NAME + " (" +
                COLUMN_1 + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                COLUMN_2 + " TEXT, " +
                COLUMN_3 + " TEXT, " +
                COLUMN_4 + " TEXT, " +
                COLUMN_5 + " INTEGER, " +
                COLUMN_6 + " TEXT" +
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

    public boolean insertInto(String nume, String email, String parola, int actualizat, String last_update){
        SQLiteDatabase database = this.getWritableDatabase();

        ContentValues contentValues = new ContentValues();

        contentValues.put(COLUMN_2, nume);
        contentValues.put(COLUMN_3, email);
        contentValues.put(COLUMN_4, parola);
        contentValues.put(COLUMN_5, actualizat);
        contentValues.put(COLUMN_6, last_update);

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
