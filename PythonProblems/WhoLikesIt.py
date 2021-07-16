def likes(names):
    length = len(names)
    if length == 1:
        str = names[0] + " likes this"
        return str
    elif length == 0:
        str = "no one likes this"
        return str
    elif length == 3:
        str = f"{names[0]}, {names[1]} and {names[2]} like this"
        return str
    elif length == 2:
        str = f"{names[0]} and {names[1]} like this"
        return str
    else:
        number = len(names) - 2
        str = f"{names[0]}, {names[1]} and {number} others like this"
        return str

    pass
