package lib;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
public class Register implements Iterable<Name>{
	/** Creates a model that represents a register,
	 * along with its subsidiary functions (such as clearing,
	 * adding, removing) You can search, clear, and sort the
	 * register as well. Functions using an ArrayList of type <Name>
	 * @author Mohammed Aziz 
	 */
	
	/**
	 * The ArrayList<Name> that acts as a register model - the functions
	 * below will delegate to the ArrayList methods to changes to be made
	 */
	private ArrayList<Name> list;
	
	
	/**Default constructor. Initialises the register with an ArrayList
	 * of type <Name>. It is empty at first, and requires names to be
	 * added to it.
	 */
	public Register()
	{
		this.list = new ArrayList<Name>();
		
		
	}
	/**Adds a name to the ArrayList<Name>, functioning as a Register.
	 * @param name - The name to be added to the Register
	 */
	public void addName(Name name)
	{
		this.list.add(name);
	}
	/**Stores the name of the item to be removed in a temp variable,
	 * and then removes the item from the Register through the ArrayList
	 * remove function
	 * @return temp - returns the item to be deleted
	 * 
	 */
	public Name removeName(int index)
	{
		Name temp = this.list.get(index);
		this.list.remove(index);
		return temp;
	}
	public Name getName(int index)
	{
		return this.list.get(index);
	}
	/** Searches for the name in the register by iterating through each
	 * item and comparing against the given argument using the Name compareTo()
	 * method
	 * @param name - the name to search for 
	 * @return true - returns true only if the item is found
	 * @return false - if it isn't found, return false
	 */
	public boolean searchRegisterByFamilyName(String name)
	{
		for(Name i: this.list)
		{
			if(i.getFamilyName().compareTo(name) == 0)
			{
				return true;
			}
			
		}
		return false;
	}
	/**Checks if the register is empty - if it is, returns true
	 * @return true - if the size of register is 0, return true
	 * @return false - if it's not empty, return false
	 */
	public boolean isRegisterEmpty()
	{
		if(this.list.size() == 0)
		{
			return true;
		}
		return false;
		
	}
	/**Clears the Register using the ArrayList function clear()
	 */
	public void clearRegister()
	{
		this.list.clear();
	}
	/**Returns the Register size using the ArrayList function size()
	 * @return this.list.size() - returns the size of the list
	 */
	public int registerSize() 
	{
		return this.list.size();
	}
	public String toString()
	{
		String output = "Register:[";
		for(Name i: this.list)
		{
			output = output + i.toString();
		}
		output += "]";
		return output;
	}
	/**Sorts the list according to the Collections method
	 */
	public void sortRegister()
	{
		Collections.sort(this.list);
	}
	/**Creates an iterator for use in a forEach loop
	 * @return this.list.iterator() - returns the iterator to use
	 */
	@Override
	public Iterator<Name> iterator() {
		return this.list.iterator();
	}
	/**Searches through the list to find any names that have the last 
	 * letter as specified in the argument - if found, it will increment
	 * the count variable, and then return it at the end
	 * @param - c - this is the character to search for
	 * @return - count - this is the number of names that have the last letter
	 * as specified 
	 */
	public int countFirstNameOccurrences(char c) {
		int count = 0;
		for(Name i: this.list)
		{
			if(i.getFirstName().charAt(i.getFirstName().length()-1) == c)
			{
				count++;
			}
		}
		return count;
	}
	
}

