package com.example.mihai.briobac.MenuTabs;

import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.mihai.briobac.R;

/**
 * Created by Mihai on 09.07.2017.
 */

public class ProfileTab extends Fragment {

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.menu_profile_tab, container, false);
        return view;
    }
}
