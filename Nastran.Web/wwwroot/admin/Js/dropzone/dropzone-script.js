//Dropzone.options.multiFileUpload = {
//    //url does not has to be written 
//    //if we have wrote action in the form 
//    //tag but i have mentioned here just for convenience sake 
//    addRemoveLinks: true,
//    autoProcessQueue: false, // this is important as you dont want form to be submitted unless you have clicked the submit button
//    autoDiscover: false,
//    paramName: 'ImagesList', // this is optional Like this one will get accessed in php by writing $_FILE['pic'] // if you dont specify it then bydefault it taked 'file' as paramName eg: $_FILE['file'] 
//   // previewsContainer: '#dropzonePreview', // we specify on which div id we must show the files
//    clickable: false, // this tells that the dropzone will not be clickable . we have to do it because v dont want the whole form to be clickable 
//    accept: function (file, done) {
//        if (file.name === "justinbieber.jpg") {
//            done("Naha, you don't.");
//        } else {
//            done();
//        }
//    },
//    error: function (file, msg) {
//        alert(msg);
//    },
//    init: function () {
//        var myDropzone = this;
//        //now we will submit the form when the button is clicked
//        $("#btn-product-submit").on('click', function (e) {
//            e.preventDefault();
//            myDropzone.processQueue(); // this will submit your form to the specified action path
//            // after this, your whole form will get submitted with all the inputs + your files and the php code will remain as usual 
//            //REMEMBER you DON'T have to call ajax or anything by yourself, dropzone will take care of that
//        });
//    } // init end
//};


var DropzoneExample = function () {
    var DropzoneDemos = function () {
        Dropzone.options.singleFileUpload = {
            url: '/Admin/Products/CreateGeneral',
            paramName: "ImagesList",
            maxFiles: 1,
            maxFilesize: 5,
            accept: function(file, done) {
                if (file.name === "justinbieber.jpg") {
                    done("Naha, you don't.");
                } else {
                    done();
                }
            }
        };
        Dropzone.options.multiFileUpload = {
            url: '/Admin/Products/CreateGeneral',
            paramName: "ImagesList",
            addRemoveLinks: true,
            autoProcessQueue: false, // this is important as you dont want form to be submitted unless you have clicked the submit button
            autoDiscover: false,
            maxFiles: 10,
            maxFilesize: 10,
            accept: function(file, done) {
                if (file.name === "justinbieber.jpg") {
                    done("Naha, you don't.");
                } else {
                    done();
                }
            }
        };
        Dropzone.options.fileTypeValidation = {
            paramName: "ImagesList",
            maxFiles: 10,
            maxFilesize: 10, 
            acceptedFiles: "image/*,application/pdf,.psd",
            accept: function(file, done) {
                if (file.name === "justinbieber.jpg") {
                    done("Naha, you don't.");
                } else {
                    done();
                }
            }
        };
    }
    return {
        init: function() {
            DropzoneDemos();
        }
    };
}();
DropzoneExample.init();