<?php
$YourPhone  = $argv[1];
$Content    = $argv[2];
$user_vht   = 'test';
$pass_vht   = 'test';
$brandname  = '0901800086';
$xmlcontent = '<?xml version="1.0" encoding="utf-8"?>
                                    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
                                      <soap:Body>
                                        <SendSMS xmlns="http://203.162.168.170/SendMTAuth/">
                                          <account_name>' . $user_vht . '</account_name>
                                          <account_password>' . $pass_vht . '</account_password>
                                          <User_ID>' . $YourPhone . '</User_ID>
                                          <Content>' . $Content . '</Content>
                                          <Service_ID>' . $brandname . '</Service_ID>
                                          <Command_Code>' . $brandname . '</Command_Code>
                                          <Request_ID>0</Request_ID>
                                          <Message_Type>0</Message_Type>
                                          <Total_Message>1</Total_Message>
                                          <Message_Index>1</Message_Index>
                                          <IsMore>0</IsMore>
                                          <Content_Type>0</Content_Type>
                                        </SendSMS>
                                      </soap:Body>
                                    </soap:Envelope>';
$URL        = "http://sms2.vht.com.vn/SendMTAuth/SendMT2.asmx?wsdl";
$ch         = curl_init($URL);
if (!is_ssl()) {
    curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, false);
    curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
}
curl_setopt($ch, CURLOPT_POST, 1);
curl_setopt($ch, CURLOPT_HTTPHEADER, array(
    'Content-Type: text/xml'
));
curl_setopt($ch, CURLOPT_POSTFIELDS, "$xmlcontent");
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
$output = curl_exec($ch);
curl_close($ch);
$dom = new DOMDocument();
$dom->loadXML($output);
?>