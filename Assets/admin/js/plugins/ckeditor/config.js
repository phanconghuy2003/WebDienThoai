/// <reference path="../ckfinder/ckfinder.js" />
/// <reference path="../ckfinder/ckfinder.js" />
/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.syntaxhightlight_lang = 'csharp';
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Assets/admin/js/plugins/ckfinder/ckfinder.html';

    config.filebrowserImageBrowseUrl = '/Assets/admin/plugins/ckfinder/ckfinder.html?type=Images';

    config.filebrowserFlashBrowseUrl = '/Assets/admin/plugins/ckfinder/ckfinder.html?type=Flash';

    config.filebrowserUploadUrl = '/Assets/admin/plugins/ckfinder/core/connector/apsx/connector.apsx?command=QuickUpload&type=Files';

    config.filebrowserImageUploadUrl = '/Data';

    config.filebrowserFlashUploadUrl = 'Assets/admin/plugins/ckfinder/core/connector/apsx/connector.apsx?command=QuickUpload&type=Flash';
    CKFinder.setupCKEditor(null,'/Assets/admin/js/plugins/ckfinder/')
};
