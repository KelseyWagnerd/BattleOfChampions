# BattleOfChampions
## Welcome to the BATTLE OF CHAMPIONS Character Storage Application
-----------------------------------------
A .NET Model View Controller project built using Razor Pages

------------------------------------------
## OVERVIEW:

> The purpose of this app is to store and validate statistics 
> belonging to Champions and Equipment created for the Battle 
> of Champions game. This app allows users to create and edit 
> Champions, give them Stats within a certain integer range, 
> and assign each Champion a piece of Equipment.

------------------------------------------
## HOW TO RUN:

1. Pull the code off GitHub and open it in Visual Studio

2. Run the app. When the homepage opens in a browser, click 
   "Champions" or "Equipment" to trigger the database migration
   screen

3. When the screen appears, follow the prompt by doing one of the three following things...
      1. Clicking the "Apply Migration" button
      2. Entering the command "update-database" in the Package Manager console in VS
      3. Entering the command "dotnet ef database update" in Command Prompt
    
4. Refresh the page, and start by adding a few pieces of Equipment to the database!
* (You can only assign Equipment when you are initially creating a Champion, not on the Edit screen.)

---------------------------------------------
## FEATURES:

This project uses the following features from the Capstone Requirements List:

1. Make your application a CRUD API.
	* The two Controller classes contain the HTTP requests for Creating, Reading, Updating, and Deleting information from the database.

2. Make your application asynchronous.
	* Most of the Controller methods are asynchronous

3. Make a generic class and use it.
	* The Create and Edit methods are both generic-- they are used in both the Champion and Equipment classes and there are versions of these methods that take different parameters for initially Creating vs Editing an object.

4. Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program.
	* In order to make a drop-down list of available Equipment, I created a dictionary of type IEnumerable for all Equipment names and populated the drop-down with each value in the list using Razor Page's ViewBag. 

--------------------------------------------
## HOW TO CREATE EQUIPMENT:

    <ol>
        <li> Give your Equipment a Name. You can go back and change this later.</li>
        <li>
            Assign it some Modifier Points, which will eventually add onto a Champion's base stats. (These will be restricted later but for now go crazy.) Here's how the skills translate to gameplay:
            <ul>
                <li>
                    ATTACK: This is how hard your character can hit. Attack correlates to how much damage an item can do to their opponent.
                </li>
                <li>
                    DEFENSE: This is how resistant your character is to taking damage. High defense items prevent more damage than those with low defense.
                </li>
                <li>
                    SPEED: This is how quickly your character moves. Speed determines who goes first, which can turn the tide of the match. Speed boosting items also give a small chance to dodge an attack and take no damage.
                </li>
                <li>HEALTH: These are your character's Hit Points. Health items increase a Champion's starting HP. When HP reaches 0, that character loses and the other is declared the winner.</li>
            </ul>
        </li>
        <li>
             Remember, Equipment needs to be added to this database first before it can be assigned to a Champion.
            Once a piece of Equipment is assigned, you can't change their assignment, but you can change the Equipment's name and stats.
        </li>
    </ol>

  --------------------------------------
  ## HOW TO CREATE CHAMPIONS

      <ol>
  <li> Give your Champion a Name and brief description for their Bio. You can go back and change this later.</li>
  <li> Assign them some Skill Points. (These will be restricted later but for now go crazy.) Here's how the skills translate to gameplay:
  <ul>
      <li> 
          ATTACK: This is how hard your character can hit. Attack correlates to how much damage they do to their opponent.
      </li>
      <li>
          DEFENSE: This is how resistant your character is to taking damage. High defense characters take lower damage than those with low defense.
      </li>
      <li>
          SPEED: This is how quickly your character moves. Speed determines who goes first, which can turn the tide of the match. Speed also gives a small chance to dodge an attack and take no damage.
      </li>
      <li>HEALTH: These are your character's Hit Points. When HP reaches 0, that character loses and the other is declared the winner.</li>
  </ul>  </li>
  <li> Select a piece of Equipment from the drop-down menu. Remember, Equipment needs to be added first before it can be assigned.
      Once a piece of Equipment is assigned, you can't change it!
  </li>
  </ol>

    
