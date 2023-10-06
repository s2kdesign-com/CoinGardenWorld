/*!
    Demo Functions. These are used to show specific features like input types, changing a style on the page
    and other features that will never be used in production.
 */

//Demo Functions, Can be Deleted
var demoBoxed = document.querySelectorAll('.demo-boxed')[0];
if(demoBoxed){
    demoBoxed.addEventListener('click',function(){
        document.querySelectorAll('.form-custom').forEach(
            function(e){
                e.classList.toggle('form-border');
            }
        )
    })

    var demoIcons = document.querySelectorAll('.demo-icons')[0];
    demoIcons.addEventListener('click',function(){
        document.querySelectorAll('.form-custom').forEach(
            function(e){
                e.classList.toggle('form-icon'); 
                e.querySelectorAll('i')[0].classList.toggle('disabled')
            }
        )
    })

    var demoFloating = document.querySelectorAll('.demo-floating')[0];
    demoFloating.addEventListener('click',function(){
        document.querySelectorAll('.form-custom').forEach(
            function(e){
                e.classList.toggle('form-label'); 
                e.classList.toggle('form-floating');
            }
        )
    })
}