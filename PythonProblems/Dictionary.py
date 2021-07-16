# Dictionaries
# Creating a dict is fairly simple, just use curly braces
thisDict = {
    "brand": "Ford", # items are key-value pairs, with : as the separator
    "model": "Mustang",
    "year": 1964
}

sal_info = {
    "Austin": 91185,
    "Boston": 90171,
    "San Jose": 100989,
    "Atlanta": 85155
}

# Adding and updating key values
sal_info["Boston"] = 95123
sal_info["Atlanta"] = 91234

# Removing entries
del sal_info["Atlanta"]

# Clearing the dictionary
# sal_info.clear()

# Showing results
# -----------------------------------------------------

# Grabbing a value and checking for one using the in keyword
# if "Austin" in sal_info:
#     print(sal_info["Austin"])
# else:
#     print("Not found")

# print(sal_info)
# print(len(sal_info))

