package main;

import java.util.ArrayList;

import lib.Player;

public class PlayerApp {

	public static String execute(ArrayList<Player> players, String fullName) {
		players.get(0).setFullPlayerName(fullName);
		String output = "";
		for(Player i: players)
		{
			if(i.getName().getFullName().contains("a"))
			{
				output = output + i.getName().getFirstName().toLowerCase() + ", " + i.getName().getFamilyName().toUpperCase() + "\n";
			}
		}
		
		return output;
	}
	
}
