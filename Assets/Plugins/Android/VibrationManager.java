package com.calljava.com;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Vibrator;
import android.widget.Toast;

public class VibrationManager {
    private Context context;

    public VibrationManager(Context context) {
        this.context = context;
    }

    // 手机震动方法
    public void vibrate(long time) {
        Vibrator vibrator = (Vibrator) context.getSystemService(Context.VIBRATOR_SERVICE);
        vibrator.vibrate(time);
    }

    // 显示消息弹出框方法
    public void showMessage(String message) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(message)
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                });
        AlertDialog dialog = builder.create();
        dialog.show();
    }

    // 返回值方法
    public String getReturnValue() {
        return "Hello from Java";
    }
}