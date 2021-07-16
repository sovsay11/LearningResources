def wrap(string, max_width):
    wrappedList = []
    wrapped = ""
    for char in string:
        wrapped += char
        if len(wrapped) % (max_width) == 0:
            wrappedList.append(wrapped)
            wrapped = ""
    wrappedList.append(wrapped)
    wrapped = "\n".join(wrappedList)
    # print(wrapped)
    return wrapped
