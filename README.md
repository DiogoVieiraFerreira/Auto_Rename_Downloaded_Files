# Auto_Rename_Downloaded_Files
The application renames downloaded files properly (with basic algorithm)  
Example for serie without multiple seasons "Slam.Dunk.E001.VOSTFR.1080p.WEB.x264", the new name is : "Slam Dunk - 001"  
Example with seasons : "Fruits.Basket.S02E15.VOSTFR.1080p.WEB.x264", the new name is "Fruits Basket - Saison 02 - 15"  
  
If you run the application in the other file, you can specify custom path and before rename files, the application  
show 2 examples of renamed files and if you not want you cant cancel the rename.

# Next Features

* User can give a custom name
    * User inform how many seasons have
    * How many episodes for each seasons

* User can create an optional file named "Exceptions" and all names on this file are remove on the name of episode.  
> Example: if the name of the episode is "Slam.Dunk.001.Time2Watch" the application detect E2 and think the e2 is episode 02...  
> if you add "Time2Watch" on Exception file, before to check the number of episode Time2Watch is removed.