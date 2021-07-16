def filter_list(l):
    newList = []
    for item in l:
        if type(item) == int:
            newList.append(item)
    return newList
