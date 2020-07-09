# python
inp = "CABFABBB"
print("".join(str(ord(s) - ord("A")) for s in inp))