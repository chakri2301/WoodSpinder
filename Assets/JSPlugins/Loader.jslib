mergeInto(LibraryManager.library, {

  GetLevelURI: function () {
    var returnStr = GetLevelURIJSstring();
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },
  LoadLevel: function(idx){
    SetLevel(idx);	
  },
});
