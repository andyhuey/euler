# Euler problem 67

# split up the input file and create a 2D array
triangle = []
File.foreach('p067_triangle.txt') do |line|
  triangle.push(line.split.map(&:to_i))
end

# add up from the bottom
x = triangle.count - 1
while x > 0
  y = 0
  while y < x
    triangle[x - 1][y] += [triangle[x][y], triangle[x][y + 1]].max
    y += 1
  end
  x -= 1
end
# result winds up in 0,0
puts(triangle[0][0])
