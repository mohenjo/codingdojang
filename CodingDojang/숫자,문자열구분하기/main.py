rst = [(s, '') if s.isdecimal() else ('', s) for s in input()]
print(
    f"str : {''.join([t[0] for t in rst])}\nint : {''.join([t[1] for t in rst])}")
