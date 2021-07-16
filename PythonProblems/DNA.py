def DNA_strand(dna):
    # matches are a to t and c to g
    matches = {"A": "T", "T": "A", "C": "G", "G": "C"}
    dnaStr = ""
    for char in dna:
        if char in matches:
            dnaStr += matches[char]
    return dnaStr
