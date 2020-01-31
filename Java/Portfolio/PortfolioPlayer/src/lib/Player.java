package lib;

public class Player implements Comparable<Player>{
	/**Creates a model of a player - which is made up of a name
	 * and dice - the dice can be rolled, and score retrieved - the
	 * name can be get/set
	 * @author - Mohammed Aziz
	 */

	/**
	 * Rollable - the dice to be used - must implement Rollable to be used
	 * Name - the name of the player
	 */
	private Rollable dice;
	private Name name;

	/**Default constructor - produces a new Name which is blank
	 * (so that it can be set later) and produces a PairOfDice
	 * which is the default dice given 
	*/
	public Player() {
		this.name = new Name();
		this.dice = new PairOfDice();
	}
	/**Constructor that provides a name - users can give a name,
	 * and it will be automatically set - instead of having to do it manually
	 * Also provides a PairOfDice - the default dice if none are given
	 * @param name - users give a name to their player
	 */
	public Player(Name name)
	{
		this.name = name;
		this.dice = new PairOfDice();
	}
	
	/**Creates a player with a name and dice.
	 * Any dice that implements Rollable can be used here (Multiple, PairOfDice, Dice)
	 * @param - name - sets the name of the player
	 * @param - dice - sets the dice type of the player
	 */
	public Player(Name name, Rollable dice)
	{
		this.name = name;
		this.dice = dice;
	}

	public Name getName()
	{
		return this.name;
	}
	public void setName(Name name)
	{
		this.name = name;
	}
	/**Sets the player name using the given argument
	 * It takes the argument, splits it into two, storing it into an array
	 * for access later, and then uses the Name methods setFirstName and
	 * setFamilyName - to set the first and family name respectively
	 * @param name - sets the name of the player
	 */
	public void setFullPlayerName(String name)
	{
		String[] array = name.split(" ");
		this.name.setFirstName(array[0]);
		this.name.setFamilyName(array[1]);
	}
	
	/**Converts the name and dice to a string based representation
	 * via delegation - following standard convention
	 * @return - returns the string representation for use in printing
	 */
	public String toString()
	{
		String output = "Player:[";
		output += this.name.toString();
		output += this.dice.toString();
		output += "]";
		return output;
	}
	
	public Rollable getRollable()
	{
		return this.dice;
	}
	/**Rolls the dice - delegating to the Rollable roll method
	 * The type of roll depends on the type that implemented Rollable (if PairOfDice
	 * rolls twice)
	 */
	public void rollDice()
	{
		this.dice.roll();
	}
	/**Gets the dice score after it has been rolled (if not rolled - it'll be 0)
	 * @return - returns the dice score
	 */
	public int getDiceScore()

	{
		return this.dice.getScore();
	}
	
	/**Overrides the compareTo method of type Object
	 * with type Player and delegates to Name's compareTo method
	 * to compare the names of players
	 * @return - returns the name of the player if it matches
	 */
	@Override
	public int compareTo(Player other) {
	
		// TODO Auto-generated method stub
		return this.name.compareTo(other.name);
	}
}
