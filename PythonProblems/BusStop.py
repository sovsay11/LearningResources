def number(bus_stops):
    # need to read the list and split the values...
    on = 0
    off = 0
    for stops in bus_stops:
        on += stops[0]
        off += stops[1]
    return on - off
