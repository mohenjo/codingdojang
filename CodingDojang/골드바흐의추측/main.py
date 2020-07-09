def get_primes(n: int):
    primelst = []
    pool = list(range(2, n + 1))
    while pool:
        newprime = pool[0]
        primelst.append(newprime)
        pool = [x for x in pool if x % newprime != 0]
    return primelst


def main():
    n = int(input('n=? '))
    if n % 2 != 0 or n <= 2: return
    primes = get_primes(n)
    rst_set = set((min(prime, n - prime), max(prime, n - prime)) for prime in primes if (n - prime) in primes)
    print(sorted(rst_set))


if __name__ == "__main__":
    main()
