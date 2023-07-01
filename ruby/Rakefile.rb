require "rake"
require "rake/testtask"

exercises = FileList["**/*_test.rb"].to_h do |test_file|
  exercise, _ = test_file.split("/")
  [exercise, test_file]
end

desc "Run all exercise tests"
task :test do
  exercises.each do |exercise, _|
    Rake::Task["test:#{exercise}"].invoke
  end
end

namespace :test do
  exercises.each do |exercise, test_file|
    Rake::TestTask.new(exercise) do |t|
      t.pattern = test_file
    end
  end
end
