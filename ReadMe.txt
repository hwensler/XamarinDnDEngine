Please note:

Screencaps of the running project are in /Documentation/Week7 screencaps as well as the "QuickSpecs" file. Since this is a demo of the game and all other components have had assignments around them, we've just included the screencaps for the battle output.

Unit Test Information:
All functions of the fighter class are tested in the MonsterTest because an instance of the fighter class cannot be instantiated. 
Since both Character and Monster inherit from Fighter, these tests are applicable for both.

CharacterTest tests only the tests unique to character (as those inherited from Fighter are tested in MonsterTest).

Getters and setters aren't tested (save for one of each in MonsterTest) because that code is part of visual studio/C# and if it's broken...
then there's something deeply wrong with visual studio and C#
