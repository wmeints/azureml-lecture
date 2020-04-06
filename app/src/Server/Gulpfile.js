var gulp = require('gulp');
var sass = require('gulp-sass');

sass.compiler = require('node-sass');

exports.compileSass = function compileSass() {
    var settings = {
        outputStyle: 'compressed'
    };

    return gulp
        .src('Stylesheets/site.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
};

exports.copyJavaScriptFiles = function copyJavaScriptFiles() {
    return gulp
        .src([
            'node_modules/bootstrap/dist/js/bootstrap.min.js',
            'node_modules/jquery/dist/jquery.min.js'
        ])
        .pipe(gulp.dest('wwwroot/js'));
};

exports.default = gulp.series(exports.compileSass, exports.copyJavaScriptFiles);