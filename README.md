# .NET 4での、PrintPreviewControl.Document の振る舞いについて

.NET 4で、PrintPreviewControl.Document の振る舞いが変わりました。
この変更に関する、公式ドキュメントが発見できませんでした。
動作検証用のリポジトリです。


## 動作検証方法


.NET 3.5と.NET 4のプロジェクトを用意してあります。
それぞれデバッグ実行すると同じように動きます。

ほぼ同一のソースコードです。
.NET 3.5では、[`Form.cs`の24行目](https://github.com/ledsun/print-preview-control-document-net-4/blob/1bcd18694a585b1c86c1660c29051217434644ee/Net3.5/Form.cs#L24)で `printPreviewControl.InvalidatePreview();` を呼び出しを追加しています。
この行をコメントアウトすると、印刷プレビューが表示されなくなります。



## 変更点

[PrintPreviewControl.Document](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.printpreviewcontrol.document?view=windowsdesktop-5.0) では、値をセットしたときに

.NET 2 ～ 3.5 の間で `InvalidatePreview()` が呼ばれません。
.NET 4 以降は `InvalidatePreview()` が呼ばれます。


## 関連情報

NET 5 のソースコードによると `InvalidatePreview()` が呼ばれます。


https://github.com/dotnet/winforms/blob/ccb12709d4931f06e625ad6109236e8de26eefad/src/System.Windows.Forms/src/System/Windows/Forms/Printing/PrintPreviewControl.cs#L104-L112

```csharp
        public PrintDocument Document
        {
            get { return document; }
            set
            {
                document = value;
                InvalidatePreview();
            }
        }
```


[印刷プレビューを表示する - .NET Tips (VB.NET,C#...)](https://dobon.net/vb/dotnet/graphics/printpreviewdialog.html)

> .NET Framework 1.1以前ではPrintPreviewControl.Documentを設定するとInvalidatePreviewメソッドが呼び出されていましたが、2.0以降では呼び出されません。

とあります。
このことから .NET 2 ～ 3.5 の間で InvalidatePreview(); が呼ばれていなかったようです。