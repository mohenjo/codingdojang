# python 3.6
count = 60 * len([0 for hh in range(24)
                  for mm in range(60) if "3" in str(hh) + str(mm)])
print(count)
# ans: 29700