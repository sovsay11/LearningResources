def is_valid_walk(walk):
    n = 0
    s = 0
    w = 0
    e = 0
    for step in walk:
        if step == "n":
            n += 1
        elif step == "s":
            s += 1
        elif step == "w":
            w += 1
        else:
            e += 1
    if (n - s) == 0 and (e - w) == 0 and len(walk) == 10:
        return True
    else:
        return False
    # determine if walk is valid
    pass
