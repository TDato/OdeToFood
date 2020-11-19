rmdir /S /Q .vs

for /d %%D in (*) do (
	echo %%~fD
	cd %%~D
	CleanMe.bat
	cd ..
)