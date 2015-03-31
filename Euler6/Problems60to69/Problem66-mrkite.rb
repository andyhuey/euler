# from the Euler forums - Thu, 27 Sep 2007, 17:30 - mrkite
# "Did a combination of the square root fraction continuation and the h/k iterator."
def check(x)
  a0 = a = Math.sqrt(x).floor
  return 0 if a * a == x
  h = kp = d = 1
  k = hp = m = 0
  loop do
    h, hp = h * a + hp, h
    k, kp = k * a + kp, k
    m = d * a - m
    d = (x - m * m) / d
    a = (a0 + m) / d
    return h if h * h - x * k * k == 1
  end
  0
end

max = 0
maxd = 0
1000.times do|d|
  r = check(d)
  max, maxd = r, d if r > max
end
puts maxd
