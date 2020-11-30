/*----------------------------------------------------------------------*/
/* wl_File v 1.2 by revaxarts.com
/* description:makes a fancy html5 file upload input field
/* dependency: jQuery File Upload Plugin 5.0.2
/*----------------------------------------------------------------------*/


$.fn.wl_File = function (method) {

	var args = arguments;

	return this.each(function () {

		var $this = $(this);

		if ($.fn.wl_File.methods[method]) {
			
		} else if (typeof method === 'object' || !method) {
			if ($this.data('wl_File')) {
				var opts = $.extend();
			} else {
				var opts = $.extend({}, $.fn.wl_File.defaults);
			}
		}

		if (!$this.data('wl_File')) {

			$this.data('wl_File', {});
			
			//The queue, the upload files and drag&drop support of the current browser
			var queue = {},
				files = [],
				queuelength = 0,
				tempdata, maxNumberOfFiles, dragdropsupport = isEventSupported('dragstart') && isEventSupported('drop') && !! window.FileReader;

			//get native multiple attribute or use defined one 
			opts.multiple = ($this.is('[multiple]') || typeof $this.prop('multiple') === 'string') || opts.multiple;

			//used for the form
			opts.queue = {};
			opts.files = [];

			if (typeof opts.allowedExtensions === 'string') opts.allowedExtensions = $.parseData(opts.allowedExtensions);

			//the container for the buttons
		

			//start button only if autoUpload is false
			

			//cancel/remove all button
			


			//filepool and dropzone
			opts.filepool = $('<ul>', {
				'class': 'fileuploadpool'
			}).insertAfter()

			//cancel one files
			.delegate('a.cancel', 'click', function () {
				var el = $(this).parent(),
					name = el.data('fileName');

				//IE and Opera delete the data on submit so we store it temporarily
				if (!$this.data('wl_File')) $this.data('wl_File', tempdata);

				//remove clicked file from the list
				$this.data('wl_File').files = files = $.map(files, function (filename) {
					if (filename != name) return filename;
				});

				//abort upload
				queue[name].fileupload.abort();

				//remove from queue
				delete queue[name];
				queuelength--;

				el.addClass('error').delay(700).fadeOut();
				
				//trigger cancel event
				opts.onCancel.call($this[0], name);
				//trigger a change for required inputs
				opts.filepool.trigger('change');
			})

			//remove file from list
			.delegate('a.remove', 'click', function () {
				var el = $(this).parent(),
					name = el.data('fileName');

				if (!$this.data('wl_File')) $this.data('wl_File', tempdata);

				//remove clicked file from the list
				$this.data('wl_File').files = files = $.map(files, function (filename) {
					if (filename != name) return filename;
				});

				el.fadeOut();

				//trigger cancel event
				opts.onDelete.call($this[0], [name]);
				//trigger a change for required inputs
				opts.filepool.trigger('change');
			})

			//add some classes to the filepool
			.addClass((!opts.multiple) ? 'single' : 'multiple').addClass((dragdropsupport) ? 'drop' : 'nodrop');


			//call the fileupload plugin
			$this.fileupload({
				url: opts.url,
				dropZone: (opts.dragAndDrop) ? opts.filepool : null,
				fileInput: $this,
				//required
				singleFileUploads: true,
				sequentialUploads: opts.sequentialUploads,
				//must be an array
				paramName: opts.paramName + '[]',
				formData: opts.formData,
				add: function (e, data) {

					//cancel current upload and remove item on single upload field
					if (!opts.multiple) {
						opts.uiCancel.click();
						opts.filepool.find('li').remove();
					}

					//add files to the queue
					$.each(data.files, function (i, file) {
						file.ext = file.name.substring(file.name.lastIndexOf('.') + 1).toLowerCase();

						queuelength++;
						var error = getError(file);

						if (!error) {

							//add file to queue and to filepool
							addFile(file, data);
						} else {

							//reduces queuelength
							queuelength--;
							//throw error
							opts.onFileError.call($this[0], error, file);
						}
					});

					//IE and Opera delete the data on submit so we store it temporarily
					if ($this.data('wl_File')) {
						$this.data('wl_File').queue = queue;
						tempdata = $this.data('wl_File');
					} else if (tempdata) {
						tempdata.queue = queue;
					}

					//trigger a change for required inputs
					opts.filepool.trigger('change');

					opts.onAdd.call($this[0], e, data);

					//start upload if autoUpload is true
					if (opts.autoUpload) upload(data);
				},
				send: function (e, data) {
					$.each(data.files, function (i, file) {
						queue[file.name].element.addClass(data.textStatus);
						queue[file.name].progress.width('100%');
						queue[file.name].status.text(opts.text.uploading);
					});

					//rename cancel button
					opts.uiCancel.text(opts.text.cancel_all).attr('title', opts.text.cancel_all);
					return opts.onSend.call($this[0], e, data);
				},
				done: function (e, data) {
					$this.data('wl_File', tempdata);
					//set states for each file and push them in the list
					$.each(data.files, function (i, file) {
						if (queue[file.name]) {
							queue[file.name].element.addClass(data.textStatus);
							queue[file.name].progress.width('100%');
							queue[file.name].status.text(opts.text.done);
							queue[file.name].cancel.removeAttr('class').addClass('remove').attr('title', opts.text.remove);
							if ($.inArray(file.name, files) == -1) {
								files.push(file.name);
								$this.data('wl_File').files = files;
							}

							//delete from the queue
							queuelength--;
							delete queue[file.name];
						}
					});


					opts.onDone.call($this[0], e, data);

					//empty queue => all files uploaded
					if ($.isEmptyObject(queue)) {

						//trigger a change for required inputs
						opts.filepool.trigger('change');
						opts.uiCancel.text(opts.text.remove_all).attr('title', opts.text.remove_all);
						opts.onFinish.call($this[0], e, data);
					}

				},
				fail: function (e, data) {
					opts.onFail.call($this[0], e, data);
				},
				always: function (e, data) {
					opts.onAlways.call($this[0], e, data);
				},
				progress: function (e, data) {
					//calculate progress for each file
					$.each(data.files, function (i, file) {
						if (queue[file.name]) {
							var percentage = Math.round(parseInt(data.loaded / data.total * 100, 10));
							queue[file.name].progress.width(percentage + '%');
							queue[file.name].status.text(opts.text.uploading + percentage + '%');
						}
					});
					opts.onProgress.call($this[0], e, data);
				},
				progressall: function (e, data) {
					opts.onProgressAll.call($this[0], e, data);
				},
				start: function (e) {
					opts.onStart.call($this[0], e);
				},
				stop: function (e) {
					opts.onStop.call($this[0], e);
				},
				change: function (e, data) {
					opts.onChange.call($this[0], e, data);
				},
				drop: function (e, data) {
					opts.onDrop.call($this[0], e, data);
				},
				dragover: function (e) {
					opts.onDragOver.call($this[0], e);
				}



			});

		} else {

		}
		//took from the modernizr script (thanks paul)

		function isEventSupported(eventName) {

			var element = document.createElement('div');
			eventName = 'on' + eventName;

			// When using `setAttribute`, IE skips "unload", WebKit skips "unload" and "resize", whereas `in` "catches" those
			var isSupported = eventName in element;

			element = null;
			return isSupported;
		}

		

	});

};

$.fn.wl_File.methods = {};