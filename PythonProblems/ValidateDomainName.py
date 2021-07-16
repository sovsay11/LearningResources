def domain_name(url):
    # check conditions for // and .
    initialConditions = ["http://", "https://", "www."]
    endingConditions = [".", "/"]
    for sub in initialConditions:
        url = url.replace("" + sub + "", "")
    for index in range(len(url)):
        if url[index] in endingConditions:
            url = url.replace(url[index::], "")
            break
    print(url)
    return url
