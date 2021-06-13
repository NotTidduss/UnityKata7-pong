Unity Kata #7 - Pong

What is Pong?
Pong is a two-dimensional sports game that simulates table tennis. 
The player controls an in-game paddle 
by moving it vertically across the left or right side of the screen. 
They can compete against another player controlling a second paddle 
on the opposing side. 
Players use the paddles to hit a ball back and forth.
 - Source: https://en.wikipedia.org/wiki/Pong#:~:text=Pong%20is%20a%20two-dimensional,a%20ball%20back%20and%20forth.

ToDo:
 - assets:
	- create field with edges
	- create paddles
	- create ball
 - scripts:
	- master script, that keeps track of the game
		- input management
		- score system
		- determine when match is over
			- restart match
	- paddle behavior
		- collision with ball
	- ball behavior
		- movement

Flow:
 1) start game
 2) play
 3) win / lose
 4) next match
 5) steps 2-4
 
Goal:
 - clean code: better documentation
 - functional pong game (no ai)