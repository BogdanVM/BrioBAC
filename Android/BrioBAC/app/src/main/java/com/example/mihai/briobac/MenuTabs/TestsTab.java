package com.example.mihai.briobac.MenuTabs;

import android.content.Context;
import android.content.Intent;
import android.support.v4.app.Fragment;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;

import com.example.mihai.briobac.IQTest;
import com.example.mihai.briobac.IQTestStart;
import com.example.mihai.briobac.R;
import com.example.mihai.briobac.SubiecteTipForm;
import com.example.mihai.briobac.VarianteForm;

/**
 * Created by Mihai on 09.07.2017.
 */

public class TestsTab extends Fragment {

    ImageButton openIqTestImgButton;
    ImageButton varianteImgButton;
    ImageButton subiecteImgButton;

    Context context = getContext();

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.menu_tests_tab, container, false);

        openIqTestImgButton = (ImageButton) view.findViewById(R.id.menu_tests_tab_iqTest_imgButton);
        openIqTestImgButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                startActivity(new Intent(getActivity(), IQTestStart.class));

            }
        });

        varianteImgButton = (ImageButton) view.findViewById(R.id.menu_tests_tab_variante_imgButton);
        varianteImgButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                startActivity(new Intent(getActivity(), VarianteForm.class));
            }
        });

        subiecteImgButton = (ImageButton) view.findViewById(R.id.menu_tests_tab_subiecte_imgButton);
        subiecteImgButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                startActivity(new Intent(getActivity(), SubiecteTipForm.class));
            }
        });

        return view;
    }
}
