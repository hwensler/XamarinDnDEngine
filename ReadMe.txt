
Unit tests for Monster and Character are in the sln Digits.

For a demo of battle actions, open the demo sln in the folder "Demo - Character and Monster."

Please note:
All functions of the fighter class are tested in the MonsterTest because an instance of the fighter class cannot be instantiated. 
Since both Character and Monster inherit from Fighter, these tests are applicable for both.

CharacterTest tests only the tests unique to character (as those inherited from Fighter are tested in MonsterTest).

Getters and setters aren't tested (save for one of each in MonsterTest) because that code is part of visual studio/C# and if it's broken...
then there's something deeply wrong with visual studio and C#