# .NET 4�ł́APrintPreviewControl.Document �̐U�镑���ɂ���

.NET 4�ŁAPrintPreviewControl.Document �̐U�镑�����ς��܂����B
���̕ύX�Ɋւ���A�����h�L�������g�������ł��܂���ł����B
���쌟�ؗp�̃��|�W�g���ł��B


## ���쌟�ؕ��@


.NET 3.5��.NET 4�̃v���W�F�N�g��p�ӂ��Ă���܂��B
���ꂼ��f�o�b�O���s����Ɠ����悤�ɓ����܂��B

�قړ���̃\�[�X�R�[�h�ł��B
.NET 3.5�ł́A`Form.cs`��24�s�ڂ� `printPreviewControl.InvalidatePreview();` ���Ăяo����ǉ����Ă��܂��B
���̍s���R�����g�A�E�g����ƁA����v���r���[���\������Ȃ��Ȃ�܂��B



## �ύX�_

[PrintPreviewControl.Document](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.printpreviewcontrol.document?view=windowsdesktop-5.0) �ł́A�l���Z�b�g�����Ƃ���

.NET 2 �` 3.5 �̊Ԃ� `InvalidatePreview()` ���Ă΂�܂���B
.NET 4 �ȍ~�� `InvalidatePreview()` ���Ă΂�܂��B


## �֘A���

NET 5 �̃\�[�X�R�[�h�ɂ��� `InvalidatePreview()` ���Ă΂�܂��B


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


[����v���r���[��\������ - .NET Tips (VB.NET,C#...)](https://dobon.net/vb/dotnet/graphics/printpreviewdialog.html)

> .NET Framework 1.1�ȑO�ł�PrintPreviewControl.Document��ݒ肷���InvalidatePreview���\�b�h���Ăяo����Ă��܂������A2.0�ȍ~�ł͌Ăяo����܂���B

�Ƃ���܂��B
���̂��Ƃ��� .NET 2 �` 3.5 �̊Ԃ� InvalidatePreview(); ���Ă΂�Ă��Ȃ������悤�ł��B