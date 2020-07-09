# python 3.6
inp = input()
cnv = ["".join(sorted(s)) for s in inp.split()]
print([True if s == "0123456789" else False for s in cnv])
