import discord
from discord.ext.commands import has_permissions, MissingPermissions
from discord.ext import commands
from discord.ext.commands import Bot
import random
import requests
from bs4 import BeautifulSoup


client = discord.Client()
Bot = Bot(command_prefix="!")
film_list = []
series_list = []
theme = ""



@Bot.command(name="suggest_film", description="Allows a user to suggest a film")
async def suggest_film(ctx, *item):
    output = " "
    output = output.join(item[:])
    for i in film_list:
        if i == output:
            await ctx.channel.send(output + " has already been suggested! Please suggest another film.")
            return
    film_list.append(output)
    await ctx.channel.send(output + " has been suggested!")

@Bot.command(name="remove_film", description="Allows an admin to remove a film")
@has_permissions(manage_roles=True)
async def remove_film(ctx, *item):
    output = " ".join(item[:])
    try:
        film_list.remove(output)
        await ctx.channel.send(output + " has been removed!")
    except:
        await ctx.channel.send("Removal of " + output + " has not been successful")

@Bot.command(name="suggest_series", description="Allows a user to suggest a series")
async def suggest_series(ctx, *item):
    output = " ".join(item[:])
    for i in series_list:
        if i == output:
            await ctx.channel.send(output + " has already been suggested! Please suggest another film.")
            return
    series_list.append(output)
    await ctx.channel.send(output + " has been suggested!")

@Bot.command(name="remove_series", description="Allows an admin to remove suggestions")
@has_permissions(manage_roles=True)
async def remove_series(ctx, *item):
    output = " ".join(item[:])
    try:
        series_list.remove(output)
        await ctx.channel.send(output + " has been removed!")
    except:
        await ctx.channel.send("Removal of " + output + " has not been successful")

#allows the user to view suggestions
@Bot.command(name="view", description="Allows a user to view the suggestions list")
async def view(ctx):

    film = "\n".join(film_list).strip("[]'")
    series = "\n".join(series_list).strip("[]'")
    embed = discord.Embed(title="Suggestions", description="")
    embed.add_field(name="Film", value=film)
    embed.add_field(name="Series", value=series)

    await ctx.channel.send(embed=embed)


#clears the suggestion list
@Bot.command(name="clear", description="Clears the list used for suggestions")
@has_permissions(manage_roles=True)
async def clear(ctx):
    try:
        film_list.clear()
        series_list.clear()
    except:
        await ctx.channel.send("Lists not cleared successfully!")
    finally:
        await ctx.channel.send("Both lists cleared successfully!")

@Bot.command(name="theme", description="Gets the current theme of the week")
async def theme(ctx):
    global theme
    await ctx.channel.send("The current week's theme is {0}!".format(theme))

@Bot.command(name="set_theme", description="Sets the current theme of the week!")
@has_permissions(manage_roles=True)
async def set_theme(ctx, *theme2):
    global theme
    theme = " ".join(theme2)
    await ctx.channel.send("This week's theme has been set to {0}".format(theme))


@Bot.command(name="randomize", description="Returns the suggestions for this week")
async def randomize(ctx):
    if len(series_list) < 2 and len(film_list) == 0:
        await ctx.channel.send("There isn't enough space in the list. Please add more.")
        return
    rint_film = random.randint(0, len(film_list) -1)
    rint_series = random.randint(0, len(series_list) -1)
    item = film_list.pop(rint_film)
    item2 = series_list.pop(rint_series-1)
    item3 = series_list.pop(rint_series-1)
    series_list.clear()
    film_list.clear()
    await ctx.channel.send(item + " is this week's film suggestion!" + "\n" +
                           item2 + " and " + item3 + " are this week's series suggestions! @everyone")


@Bot.command(name="search", description="Searches MAL's pages for anime")
async def search(ctx, *item):
    search_list = []
    url = "https://myanimelist.net/search/all?q="
    output = "%20".join(item[:])
    url = url + output
    response = requests.get(url)
    if(response.status_code == 404):
        await ctx.channel.send("Wasn't able to find anything... Try searching again!")
        return
    soup = BeautifulSoup(response.text, 'html.parser')
    soupitems = soup.find_all('a', class_="hoverinfo_trigger")
    print(soupitems)
    count = 1
    for i in soupitems:
        search_list.append(str(count) + ") " + i.get('href'))
        count=count+1
    output = "\n".join(search_list[:3])
    await ctx.channel.send(embed=discord.Embed(title="Search Results", description=output))






@Bot.event
async def on_ready():
    print('Logged in as')
    print(Bot.user.name)
    print('------')


Bot.run(TOKEN)





