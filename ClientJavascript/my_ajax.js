function ajax(url, fonctionDeCallback, httpMethod, data, contentType) {

        var xhr = new XMLHttpRequest();

        if ( !data ) data = null;

        if ( !httpMethod ) httpMethod = 'GET';

        xhr.onreadystatechange = fonctionDeCallback;

        try{
            xhr.open( httpMethod, url, true );        
        }

        catch (e) {
            alert(e);

        }

        if( contentType ) {

            xhr.setRequestHeader("Content-Type", contentType);
        }
        xhr.send(data);

}

