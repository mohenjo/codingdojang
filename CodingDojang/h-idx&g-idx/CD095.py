# python 3.6
inp = "0 15 4 0 7 10 0"
inpg = list(sorted(map(int, inp.split()), reverse=True))
inph = list(filter(bool, inpg))
h_idx = 0
for h in range(1, len(inph) + 1):
    if len([cited for cited in inph if cited >= h]) >= h:
        h_idx = h
g_idx = 0
for g in range(1, len(inpg) + 1):
    if sum(inpg[:g]) >= g**2:
        g_idx = g
print("h-index: %d\ng-index: %d\n" % (h_idx, g_idx))