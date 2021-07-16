if __name__ == "__main__":
    s = input()
    yay = [0, 0, 0, 0, 0]
    for char in s:
        if char.isalnum():
            yay[0] = 1
    for char in s:
        if char.isalpha():
            yay[1] = 1
    for char in s:
        if char.isdigit():
            yay[2] = 1
    for char in s:
        if char.islower():
            yay[3] = 1
    for char in s:
        if char.isupper():
            yay[4] = 1
    for result in yay:
        if result == 1:
            print(True)
        else:
            print(False)
