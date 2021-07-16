def nb_year(p0, percent, aug, p):
    convPerc = percent / 100
    growPop = p0 + p0 * convPerc + aug
    years = 1
    while growPop < p:
        growPop += growPop * convPerc + aug
        growPop = int(growPop)
        years += 1
        print(growPop)
    print(f"{p0} {percent} {aug} {p}")
    return years
