chdir "c:\sgs projects\organizer\download"

copy /y "C:\SGS Projects\organizer\organizer\bin\Release\organizer.exe"
copy /y "C:\SGS Projects\organizer\organizer\bin\Release\organizer.exe.config"
copy /y "C:\SGS Projects\organizer\organizer\bin\Release\NetSpell.SpellChecker.dll"
copy /y "C:\SGS Projects\organizer\organizer\bin\Release\ExtendedRichTextBox.dll"
copy /y "C:\SGS Projects\organizer\organizer\bin\Release\RichEditor.dll"
copy /y "C:\SGS Projects\organizer\organizer\bin\Release\ReadMe.txt"

del /q organizer.zip
zip -q -r organizer.zip organizer.exe organizer.exe.config ProGridComponent.dll ReadMe.txt ExtendedRichTextBox.dll RichEditor.dll NetSpell.SpellChecker.dll

ftp -v -n -s:upload.txt
