def namelist(names):
    # get the length of the names
    length = len(names)
    # empty array to hold values
    allNames = []
    # iterate through the names and add the values to the empty array
    for name in names:
        allNames.append(list(name.values())[0])
    
    # comparisons to determine what kind of string to return
    if length > 2:
        # join everything except for the last name
        partialString = ", ".join(allNames[0:len(allNames)-1])
        # add the last name
        fullString = partialString + " & " + allNames[len(allNames)-1]
        return fullString
    elif length == 2:
        return " & ".join(allNames)
    elif length == 1:
        return allNames[0]
    else:
        return ''