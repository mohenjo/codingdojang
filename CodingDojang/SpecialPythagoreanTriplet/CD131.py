# python 3.6
# a + b + c = 1000, a^2 + b^2 = c^2 --> a^2 + b^2 = (1000 - (a+b))^2, where a < b < c
sol = [(a, b) for a in range(1, 1000) for b in range(1, 1000) if a**2 + b**2 == (1000 - (a + b))**2 and a < b]

a = sol[0][0]
b = sol[0][1]
c = 1000 - (a + b)
print(a * b * c)
# ans: 31875000