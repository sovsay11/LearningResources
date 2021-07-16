def mutate_string(string, position, character):
    stringList = list(string)
    stringList[position] = character
    mutatedString = "".join(stringList)
    return mutatedString
