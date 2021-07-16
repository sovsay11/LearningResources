# Complete the solve function below.
def solve(s):
    words = list(s.split(" "))
    capWords = []
    for word in words:
        if word.isalpha():
            capWords.append(word.capitalize())
        else:
            capWords.append(word)
    return " ".join(capWords)
