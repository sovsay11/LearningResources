def duplicate_encode(word):
    str = ""
    for char in word:
        counter = 0
        for compare in word:
            if char.lower() == compare.lower():
                counter += 1
        if counter > 1:
            str += ")"
        else:
            str += "("
    return str
