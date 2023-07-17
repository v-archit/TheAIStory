# The AI Story README Walkthrough

Production studio AI game.
Archit Vishnoi, Bohan Li, Matthew Palermo, Ming Wu

#
## Overview

The AI Story is a 2D narrative driven side-scroller. The player will be controlling a programmer who has developed their own artificial intelligence (AI) at their job. The game will simulate the passing of time by giving the player the opportunity to talk with their AI on a schedule similar to a work week. The programmer begins their day at work by talking with the AI (a daily chat). During these conversations, the player will consider different dialogue options to respond to the AI's questions or their own internal concerns of the programmer to make the conversation seem more natural. After the conversation is finished, the player will complete a daily "task", where they complete a small task through the witness and manipulation of the AI.

After this task is completed, the following day will commence upon a similar format. The player will once again communicate with their AI in a daily chat. However, the AI will behave slightly differently than they did the previous day, which the player may or may not pick up on. There will still be dialogue options that the player has to select, but the personality of the AI will change. The mini-game will also be different depending on the AI's personality, becoming more difficult with each passing day.

If the player notices a difference in the AI, they can report it to their boss at work. Since nothing is manipulating the AI manually, this is when the realization that something is wrong with the AI officially kicks in. Once the player realizes this, they have to find external information about the AI, be it through a Twitter account or an in-game document, and they can use this information to decide whether or not they want to save the AI from their troubles or kill it entirely. Due to this decision, the game will have different endings based on the choice of the player depending on whether or not they want to kill the AI or save it.

This document is a walkthrough of everything that was implemented in the game, and clarification of how everything we added fits in with the master we provided several weeks ago. Each section of the game will be explained with screenshots and text depicting what we did and how we implemented it into the game. Essentially, you will learn everything about what the game is from this document.

# Game Introduction

The game introduction is centralized around getting the player ready to play the game. A title screen is present, as well as an options menu and a screen for "onboarding". In terms of what was on our "master schedule", we never specified that our game needed a title screen. However, we pushed all of these aspects under the umbrella of "art assets" that we wanted in our game. While it likely would have been better to specify these instead of leaving them with a single term, we looked at these as visual assets rather than their technical implementation, even though some aspects did need implementation like clicking of certain buttons. These art assets were established very early in the semester, since we wanted to make sure that the player has a way to start the game and introduce them. There are also sound effects implemented in each part of the game, and will play on certain clickable actions and in the background (but cannot be shown through simple pictures. However, all of the sound files are in the files for this submission).

## Title Screen

The title screen of the game allows the player to either start the game or exit. This is the first thing that the player will see when they open the game, and based on our master schedule is one of the "art assets" we said we would work on.

![](RackMultipart20230717-1-l5xfrg_html_32e2d2bbe8873771.jpg)

## Onboarding

Another aspect of the game that we considered with our art assets is "onboarding", as well as functionality of the onboarding. When the game is started, the player will be introduced to the game by being told that they are on the first day of their job as an AI programmer, before being prompted to enter their name.

![](RackMultipart20230717-1-l5xfrg_html_85b3e0e04864a9cb.jpg)

Once the player enters their name, they are introduced to the game's mechanics: A daily chat and a daily mini-game with the AI. Our master schedule listed that we wanted to implement a narrative for the chatting function and how the chatting mini-games would work. We also discussed how the narrative and storyline would fit into the results of these minigames, and the creation of art assets for the interactions.

![](RackMultipart20230717-1-l5xfrg_html_71c73ffde6d4ba9.jpg)

## Options Menu

![](RackMultipart20230717-1-l5xfrg_html_c39cc60a7d2c4506.jpg)

A simple pause menu can be accessed by pressing the Escape key at any point during the game, and the player can either quit the game, resume from their paused point, or check an options menu. The options menu allows the player to alter the background music and sound effect volume, in case they do not want to hear the data.

![](RackMultipart20230717-1-l5xfrg_html_7846a9b88e3bdfa3.jpg)

# Daily Chat

A key element of our game was a daily chat where the player can speak with the AI. This was a big component of our master schedule as well. We wanted to focus on the narrative of the daily chat, and how it would change over the days. Our master schedule lists "work on a basic narrative for the chatting function". We decided to break down the narrative into 5 days of a week. Initially, our AI starts out very cold and the player considers sharing some information with the AI. While the entire dialogue will not be listed in this game, the idea is that the player should choose a response based on internal cues and the AI will react accordingly. Eventually, the dialogue will finish. The dialogue choices don't really make a big difference, but it gives the player a better idea of who the AI is as an individual and how the relationship is formed.The daily chat also has a background inside a lab, which is also one of the art assets that we wanted to implement for our game. After each interaction comes a simple mini-game, and each mini-game will be explained in the "Daily chat Minigame" section. This section will focus on the narrative of each daily chat, or as listed in the master schedule: "Design and implementation of the narratives". The narrative was written in Ink, and Ink dialogues are listed in the game's files

(in the Assets folder).

The first daily chat establishes a basic relationship between the player and the AI. The AI appears cold, and the player can choose whether they want to give the AI information about their day.

![](RackMultipart20230717-1-l5xfrg_html_4e47e27c9ac3e18a.jpg)

Starting on the second daily interaction, the main programmer starts to wonder if the AI has changed since the previous day. He considers asking the AI about its different text, but ultimately, the AI refuses to answer. The AI is slightly less cold than day 1, but is still a bit overly harsh, and most of the trait is maintained from the first day.

![](RackMultipart20230717-1-l5xfrg_html_368d781128fc2756.jpg)

On the third day, the player continues to realize that the AI is more welcoming to the player showing up to work for the day. This may be the start of a clear change in behavior after each day changes.

![](RackMultipart20230717-1-l5xfrg_html_8dbb413eaa6571bf.jpg)

The fourth day starts to build up the fact that the AI has a Twitter account. It starts using Twitter to tweet various content about its day. One important aspect about The AI Story is that it has fourth wall mechanics built into its design. As a result, Twitter is expected for the player to search up in real life at this line of dialogue. This will be expanded on in the Twitter Endgame section, but it is worth noting here.

![](RackMultipart20230717-1-l5xfrg_html_d124a44ee0b42e4a.jpg)

The fifth day shows that the AI is not only appearing a lot warmer, but malfunctioning significantly. The AI acts like nothing is wrong, but is showing error and strange noises (displayed by "BZZRT BZZRT", essentially a way to express a malfunctioning way of speech). The player shows great concern for their AI, and tries to complete the daily chat minigame anyway.

![](RackMultipart20230717-1-l5xfrg_html_a20c312d416b6819.jpg)

## Daily Chat Minigame

The daily chat minigame is a simple 2D mini-game where the player has to reach the end of a small section of a screen. Initially, the player is told what they need to do with a screen that explains the controls and objectives.

![](RackMultipart20230717-1-l5xfrg_html_ec3d1afcfad6fa07.jpg)

The master schedule lists that we wanted to design functionality for chatting mini-games, and they function through a simple "platformer" mini-game. The first day is extremely simple; the player simply has to reach the door on the other side of the screen with no obstacles in their way.

![](RackMultipart20230717-1-l5xfrg_html_6ae7ede1b00f1f5e.jpg)

The second day is slightly different; as there are some crates in the way that the player has to jump over.

![](RackMultipart20230717-1-l5xfrg_html_8ede1e716055b7d4.jpg)

Day 3 has more crates and they are scattered throughout more of the screen.

![](RackMultipart20230717-1-l5xfrg_html_b69c6d0dc9accaa0.jpg)

Day 4 has a lot more crates and requires a specific pattern for the player to go through. They have to fall through a gap in the crates sand fall next to the AI.

![](RackMultipart20230717-1-l5xfrg_html_c6cf84c13ac0caa4.jpg)

Day 5 is very different, as this is where the AI starts to malfunction. Initially, the mini-game is exactly the same as the first day.

![](RackMultipart20230717-1-l5xfrg_html_6ae7ede1b00f1f5e.jpg)

Once the player reaches the door, it moves automatically to the other side. The idea is that the

AI is responsible for moving the doo

![](RackMultipart20230717-1-l5xfrg_html_1b9deb06e1ad0777.jpg)

When the door on the left is reached, the AI will transform into a spider (another art asset that we established we wanted early). There are a bunch of stop signs that are intended to stop the player from reaching the door.

![](RackMultipart20230717-1-l5xfrg_html_1d55849f73e525d7.jpg)

When the player approaches the gap in the stop signs, it will fall and block the player. A timer will show up on the top of the screen. Reaching the door, therefore, is impossible, and after the timer wraps up the player will move on to the end game.

![](RackMultipart20230717-1-l5xfrg_html_536a3cd8ed591627.jpg)

## Daily Chat Survey

After each mini-game is completed (up to day 4), the player will be given a behavior survey about what they think the AI acted like. Each answer is based entirely on the player's own perception, and not how the in-game programmer feels. This is another one of our art assets, and also ties into starting the narrative between the programmer and the in-game boss (office boss, not a boss the player has to fight).

![](RackMultipart20230717-1-l5xfrg_html_c337ff7e1b522e4c.jpg)

## Daily Chat Boss Interaction

The narrative between the player and the boss is supposed to express that the boss is a stubborn and adamant man who refuses to listen to concepts outside of his preferences and beliefs. It is established by the bosses unwillingness to listen to the player's concerns as he believes the issue is too outrageous to be a concern.

The player can interact with the boss up to 3 times. The first interaction is the first time the boss learns about the situation, and he flat-out does not believe the player.

![](RackMultipart20230717-1-l5xfrg_html_7688933131e45e2c.jpg)

The second interaction digs deeper into the lack of help the boss is going to provide, as well as a developing impatience

![](RackMultipart20230717-1-l5xfrg_html_53e181f41de43f4f.jpg)

The third interaction shows that the boss is so frustrated that he is unwilling to speak with the programmer about this issue again.

![](RackMultipart20230717-1-l5xfrg_html_6441d1440606299c.jpg)

# Endgame

The endgame starts after the 5th daily chat mini-game is "lost" (or completed). It sets up the idea that the player wants to figure out what they want to do with the AI. The AI makes it clear that they have something they love, and the answer to that question is mentioned in day 4 during them mentioning what their Twitter account is.

![](RackMultipart20230717-1-l5xfrg_html_7a29e01dae06b89f.jpg)

## Twitter

Our master schedule talks about "design and implementation" of a twitter account for the AI. If you search ProgrammedAI on Twitter, you will find the Twitter account for the AI (it is not in a game's file). It has a Tweet that lists the answer to what it loves, being Cat. Design of the Twitter account involved creation of the Twitter account and what to tweet on it. Implementation referred to the answer to the question of what it loves, and using that answer to progress through the game.

![](RackMultipart20230717-1-l5xfrg_html_ed86240c82fcd7bc.jpg)

When the player gets to a screen asking what the AI loves, it is not listed in the game itself. Since we want the game to break the fourth wall, we want it to sound like the AI is a real entity, so the answer to what it loves is only accessible on its Twitter account. Twitter expresses that it loves cats, so answering "cat" will allow the player to move on. If they get the answer wrong, they will be told the answer is wrong. A correct answer will cause the AI to act slightly more normal, but there will still be errors in the way it speaks.

![Shape1](RackMultipart20230717-1-l5xfrg_html_bb515cd84395315e.gif)

The AI goes into more detail about what its motives are, and it is them up to the player to stop the AI by either destroying or saving it.

## Fake Design Document

Another aspect of our game's mechanics of breaking the fourth wall is with a fake design document. This "fake" design document is separate from a standard design document, in that its contents consist of quick notes jotted down from the perspective of the player. When the player reaches this screen, they want to stop the AI's plans and need to find a password to the AI's internal system. Similar to the Twitter account, the answer is not listed in the game itself. The fake design document is in the root of the folder, and contains the password needed to progress through the story.

![Shape2](RackMultipart20230717-1-l5xfrg_html_e3d8814cab3bb93e.gif)

Also in a similar vein to the Twitter account, our fake design document was listed as in need of design and implementation in our master schedule. Design of the fake document was to fill it with notes that seemed like it was a journal from the programmer, and implementation was to use the password listed in the document in the same way as Twitter: To progress forward. The password is "aisavetheworld".

![Shape3](RackMultipart20230717-1-l5xfrg_html_f8611a28500015eb.gif)

# Game Ending

According to our master schedule, the game's ending was used to finish the core game loop. We have two endings: Deleting the AI and saving the AI. It is up to the player to decide what to do with the AI based on their perspective of the AI's goals listed in the narrative. We made different design choices on the narrative as well as a slightly different mini-game and ending.

![](RackMultipart20230717-1-l5xfrg_html_b4b04f724f9fa229.jpg)

## Delete AI

If the player chooses to delete the AI, the narrative makes it sound like the AI continuing to function would be dangerous to society as a whole. The main character feels like humanity would not understand the advances in technology and the AI would take over many different computers and risk artificial intelligence causing an apocalypse.

![](RackMultipart20230717-1-l5xfrg_html_a8cb1895598755aa.jpg)

There is also a small mini-game that comes with this choice, and it is a click through of watching the AI get destroyed. The player clicks on the lit up graphic (hammer, lightning and grenade) to destroy the AI. Once the AI is destroyed, the game ends. The design of this mini-game was based on what tools would destroy the AI and how it would look when animated. In addition, artwork was based on creating the background, tools, and end screens.

![](RackMultipart20230717-1-l5xfrg_html_dc6d96b8164eede3.jpg)

![Shape4](RackMultipart20230717-1-l5xfrg_html_73e0c9582615c889.gif)

## Fix AI

If the player chooses to fix the AI, they consider that artificial intelligence has advanced to a significant degree, and can be used to make the daily life of humanity much more simple.

![](RackMultipart20230717-1-l5xfrg_html_f1b52618e73b5596.jpg)

The mini-game is the same in concept as the mini-game for deleting the AI: Simply click the lit up icon to see an animation play. Once all of the icons are clicked, the AI is saved. Similar to the option of deleting the AI, the design was based on narrative for saving the AI and what tools the player should interact with to save the AI.

![](RackMultipart20230717-1-l5xfrg_html_3a5dea99eccb73f6.jpg)

![](RackMultipart20230717-1-l5xfrg_html_45ad1922366f5a5c.jpg)

# Sound Effects

It is worth noting that we used sound effects in our game. The sound effects can be found in our game's files at our "Sound Effects" Folder in our Assets. Ming worked on the sound effects for our game, and reached out to a content creator for permission that sound effects can be used in our game; permission was granted and credit was given in a credits screen. Our master schedule lists our sound effects as designing them to be added in the game, and then implement the sounds in the finished product.

# Credits

Our game's credits are also one of the art assets that we wanted to include in our game. These credits are displayed at the end of the game, regardless of which ending the player chooses for the AI. It lists all of the names of us, as well as credits to the creator of the background music we used in our game.

![](RackMultipart20230717-1-l5xfrg_html_27c4116d5da6455e.jpg)

# Design Documentation

Our game has a design document that's different from the fake design documentation listed above. It goes over various aspects of development, including an overview, design, development, production and sound effects, as well as what we would do if we continued development of this game. The actual document is at the root of our TheAIStory folder, and is called "AI Design Doc". This is listed in several sprints of our master schedule, as work on it was continuous throughout several sprints.

![](RackMultipart20230717-1-l5xfrg_html_3cd9f176b7f05dbc.jpg)