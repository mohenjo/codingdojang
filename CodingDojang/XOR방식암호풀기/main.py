def main():
    with open("cipher1.txt", 'r') as f:
        encrypt = f.read()
    encrypt = tuple(map(int, encrypt.split(',')))

    # 소문자 ascii: [97,122]
    lower_range = range(97, 123)
    keys = [(p, m, s) for p in lower_range for m in lower_range for s in lower_range]  # 암호화키
    # 공백이 제일 많이 검출되는 (영어 문장이라 판단되는) 키에 대한 메세지
    max_spaces, decrypt_key, decrypt_msg = 0, None, None  # 최대 공백수, 암호화키, 해독 문자열
    for key in keys:
        tmp_decrypt = tuple(e ^ key[idx % 3] for idx, e in enumerate(encrypt))
        foo = tmp_decrypt.count(32)  # 공백 개수
        if foo > max_spaces:
            max_spaces = foo
            decrypt_key = key
            decrypt_msg = tmp_decrypt[:]

    print("encryption key:", "".join(chr(c) for c in decrypt_key))  # god
    print("decrypted message:", "".join(chr(c) for c in decrypt_msg))  # (The Gospel..)
    print("sum of ascii values in decrypted message: ", sum(decrypt_msg))  # 107359


if __name__ == "__main__":
    main()
